            public async System.Threading.Tasks.Task SerializeAsync(List<ProgrammInfo> list)
            {
    
                var stringList = list.Select(x => x.ToString());
    
                using (FileStream fs = File.AppendAllLines("save3.json", stringList))
    ...
