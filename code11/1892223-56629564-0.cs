       private Boolean checkemail(string _email)
       {
            bool emailavailable = false;
            
            using (your context)
            {
                var res = context.Persona.Where(p => p.Email == _email).ToList();
                if (res != null)
                emailavailable = true;
            }
            return emailavailable;
        }
