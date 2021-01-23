     public ActionResult date()
        {
            int j = 0;
            int output = 0;
            DateTime[] startDate = new DateTime[6];
           
            startDate[0] = new DateTime(2011, 11, 1);
            startDate[1] = new DateTime(2011, 11, 6);
            startDate[2] = new DateTime(2011, 11, 16);
            startDate[3] = new DateTime(2011, 11, 17);
            startDate[4] = new DateTime(2011, 11, 17);
            startDate[5] = new DateTime(2011, 11, 17);
            
            
            DateTime[] endDate = new DateTime[6];
            endDate[0] = new DateTime(2011, 11, 4);
            endDate[1] = new DateTime(2011, 11, 8);
            endDate[2] = new DateTime(2011, 11, 18);
            endDate[3] = new DateTime(2011, 11, 17);
            endDate[4] = new DateTime(2011, 11, 22);
            endDate[5] = new DateTime(2011, 11, 19);
           
            //5-7
                                                   //7-9
                                                  //15-20
            List<DateTime> start = new List<DateTime>();
            List<DateTime> end = new List<DateTime>();
      
            DateTime interStart = default(DateTime);
            DateTime interEnd = default(DateTime);//initialize
            start.Add(interStart);
            end.Add(interEnd);
           
            
             for (int i = 0; i < startDate.Length ; i++)
             {
                 if(i < (startDate.Length-1)){
                  j=i+1;
                 }
                 else{
                     j = i;
                 }
                 if ((startDate[i] <= endDate[j]) && (endDate[i] >= startDate[j]))
                 {
                     List<DateTime> intermediateStart = new List<DateTime>();
                     intermediateStart.Add(startDate[i]);
                     intermediateStart.Add(startDate[j]);
                     interStart = intermediateStart.Min();
                     List<DateTime> intermediateEnd = new List<DateTime>();
                     intermediateEnd.Add(endDate[i]);
                     intermediateEnd.Add(endDate[j]);
                     interEnd = intermediateEnd.Max();
                     if ((start.Last() <= interEnd) && (end.Last() >= interStart))
                     {
                       
                             List<DateTime> finalStartValue = new List<DateTime>();
                             finalStartValue.Add(start.Last());
                             finalStartValue.Add(interStart);
                             List<DateTime> finalEndValue = new List<DateTime>();
                             finalEndValue.Add(end.Last());
                             finalEndValue.Add(interEnd);
                             DateTime finalStart = finalStartValue.Min();
                             DateTime finalEnd = finalEndValue.Max();
                             start.Remove(start.Last());
                             end.Remove(end.Last());
                             start.Add(finalStart);
                             end.Add(finalEnd);
                     }
                     else
                     {
                         start.Add(interStart);
                         end.Add(interEnd);
                     }
                 }
                 else
                 {
                     start.Add(startDate[i]);
                     end.Add(endDate[i]);
                     //remove(start.first);
                 }
             }
            int count=(start.Count())-1;
            for (int k = 0; k <= count; k++) {
                TimeSpan span = end[k]-start[k];
                int diff = span.Days;
                output = diff + output;
                
            }
                ViewBag.finalOutput = output;
                return View();
        }
    }}
