    namespace Reports.Shared.Validation
    {
        public class IdentifierValidationViewComponent : ViewComponent
        {
            private readonly IdentifierValidationDB _IdentifierValidationContext;
    
            public IdentifierValidationViewComponent(IdentifierValidationDB IdentifierValidationContext)
            {
                _IdentifierValidationContext = IdentifierValidationContext;
            }
    
            public List<IdentifierValidation> InvalidIdentifiers { get; set; }
    
            public async Task<IViewComponentResult> InvokeAsync(string date)
            {
                InvalidIdentifiers = await _IdentifierValidationContext.IdentifierValidations.FromSqlRaw("EXEC Reports.IdentifierValidation {0}", date).ToListAsync();
                
                if(InvalidIdentifiers.Count() > 0)
                {
                    ViewContext.HttpContext.Items["InvalidIdentifier"] = "Detected";
                }
                return View(InvalidIdentifiers);
            }
        }
    }
