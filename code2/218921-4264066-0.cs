        StringBuilder sb = new StringBuilder();
            
            foreach(Person p in person)
            {
            string status = p.Age >= 18 ? "Adult" : "Not Adult";
            
            sb.AppendLine(String.Format("{0} {1} {2}",p.Name,p.Age.ToString(),status));
            sb.AppendLine(Environment.NewLine);
    
            }
