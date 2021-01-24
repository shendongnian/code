        #region Properties
        [Required]
        [BindProperty]
        [RegularExpression("^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Insira uma hora no formato HH:MM")]
        public string Inicio { get; set; }
        [Required]
        [BindProperty]
        [RegularExpression("^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Insira uma hora no formato HH:MM")]
        public string Fim { get; set; }
        [BindProperty]
        public Horario Horario { get; set; }
        #endregion
        #region Handlers
        public void OnGet()
        {
          
        }
        public async Task<IActionResult> OnPost()
        {
            TimeSpan inicio;
            if (!TimeSpan.TryParse(Inicio, out inicio))
            {
                ModelState.AddModelError("", "Hora de Início inválida.");
            }
            TimeSpan fim;
            if (!TimeSpan.TryParse(Fim, out fim))
            {
                ModelState.AddModelError("", "Hora de Fim inválida.");
            }
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Dados inválidos.");
                return Page();
            }
         
            Horario.Inicio = inicio;
            Horario.Fim = fim;
            _horarioService.Add(Horario);
            try
            {
                await _horarioService.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                //This either returns an error string, or null if it can’t handle that error    
                var error = e;
                if (error != null)
                {
                    // Log Error and notify user 
                    _logger.LogError($@"Falha ao criar Horário para o UAP {Horario.Uap}\n Erro: {e.InnerException}");
                    ModelState.AddModelError(string.Empty, $"O horário {Horario.Inicio}-{Horario.Fim} {Horario.Uap} já existe.");                    
                    _toastNotification.AddWarningToastMessage($"O horário {Horario.Inicio}-{Horario.Fim} {Horario.Uap} já existe.");
                    return Page(); //return the error string
                }
                throw; //couldn’t handle that error, so rethrow
            }
            // Notify user action was successful and log information
            _toastNotification.AddSuccessToastMessage("Horário adicionado.");
            _logger.LogInformation($@"Adicionado Horário {Horario.Inicio}-{Horario.Fim} {Horario.Uap}. Data: {DateTime.Now.ToString("dd-MM-yyyy hh:mm")}");
            return RedirectToPage("Index");
        }
        #endregion 
