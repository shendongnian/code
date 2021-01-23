    Tables.Select(t =>
    {
       switch (t.ToString().Replace("Project.", ""))
       {
           case "Job":
               TableIsJob((Job)t, b);
               break;
           case "Estimation":
               TableIsEstimation((Estimation)t, b);
               break;
       }
    });
