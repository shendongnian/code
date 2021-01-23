        public static String GetFKPropertyName(this NavigationProperty property)
        { 
            var depProp = property.GetDependentProperties().FirstOrDefault();
            if (depProp == null)
                return "";
            return depProp.Name;
            
        }
