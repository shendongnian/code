            foreach(var item in query0)
            {
               Console.WriteLine($"ID:{item.ID}, Desc1:{item.Desc1}, Desc2:{item.Desc2}, Status:{item.Status}");  
            }
            //if you want to query a particular id:
            var queryid = query0.Where(item => item.ID == particularID);
