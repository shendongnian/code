            var idList = GetList();
    
            //The complete heirarchy list
            var ancestorList = new List<Record>();
    
            //startId will determine the beginning Id of your query
            int? startId = 3;
    
            while (true)
            {
    
                if (startId != null)
                {
                    ancestorList.Add(GetList()
                      .Where(m => m.Id == startId)
                      .FirstOrDefault());
                }
                else
                {
                    break;
                }
    
                startId = GetPreviousId((int)startId);
            }
    
            //this is just for checking the list of ids, this is unnecessary
            foreach (var item in ancestorList)
            {
                Console.WriteLine(item.Id);
            }
            
            Console.ReadLine();
