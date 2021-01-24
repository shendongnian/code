    List<Droits> droit_utilisateur = GetDroits(username);
                Type myType = e.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
    
                foreach (PropertyInfo prop in e.GetType().GetProperties())
                {
                    object propValue = prop.Name;
                    if (droit_utilisateur.Any(s => s.nom_colonne.Contains(prop.Name/*, StringComparison.OrdinalIgnoreCase)*/) == false))
                    {
                        prop.SetValue(e, Convert.ChangeType(null, prop.PropertyType), null);
                    }
                }
    
    
                    return e;
