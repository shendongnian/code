        public ConvidarAmigosEmailViewModel()
            {
                ContactosComEmail = new ObservableCollection<Contacto>();
                
            }
        
            public async Task LoadData()
            {
                await ObterContactos();
            }
    
    
  
    
