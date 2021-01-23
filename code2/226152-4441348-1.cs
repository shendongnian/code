    public class ProcessorFactory
    {
        static IDictionary<string, IFileProcessor> ProcessorsByExtension = 
            new Dictionary<string, IFileProcessor>();
            
        static ProcessorFactory() 
        {
            var processorTypes = 
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                where typeof(IFileProcessor).IsAssignableFrom(t)
                select t;
            foreach(var t in processorTypes)
            {
                // Preferably use your DI framework to generate this.
                var processor = (IFileProcessor)Activator.CreateInstance(t);
                foreach(var ext in processor.FileExtensions)
                {
                    if(ProcessorsByExtension.ContainsKey(ext))
                    {
                        throw new InvalidOperationException(
                            "Multiple processors are registered to extension " + ext);
                    }
                    ProcessorsByExtension[ext] = processor;
                }
            }
        }
    
        public IFileProcessor GetProcessorForFile(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            return ProcessorsByExtension[extension];
        }   
    }
