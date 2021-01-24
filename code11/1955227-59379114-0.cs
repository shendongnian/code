            public string Path_Etablissement
            {
                get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Zonedetec\Gestionnaire d'établissement Scolaire\Etablissements.xml"; }
            }
            public string Path_Teacher
            {
                get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Zonedetec\Gestionnaire d'établissement Scolaire\Teachers.xml"; }
            }
            public string Path_Student
            {
                get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Zonedetec\Gestionnaire d'établissement Scolaire\Students.xml"; }
            }
