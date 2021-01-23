    foreach (var patientGroups in groups)
                 {
                     Console.WriteLine("Patient Level = {0}", patientGroups.Key);
                     foreach (var studyGroups in patientGroups.StudyGroups)
                     {
                         Console.WriteLine("Study Level = {0}", studyGroups.Key);
                         foreach (var seriesGroups in studyGroups.SeriesGroups)
                         {
                             Console.WriteLine("Series Level = {0}", seriesGroups.Key);
                             foreach (var instance in seriesGroups)
                             {
                                 Console.WriteLine("Instance Level = {0}", instance.InstanceGuid);
                             }
                         }
                     }
                 
                 }
