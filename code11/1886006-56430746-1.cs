      else if (results.Data is List<Application> applications)
                {
                    csvWriter.Configuration.RegisterClassMap(new ApplicationCsvWriterMap(results.RequiredFields));
                    csvWriter.WriteRecords(_dtoMapper.MapApplications(applications));
                }
