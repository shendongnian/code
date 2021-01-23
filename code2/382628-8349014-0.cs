     /// <summary>
     /// Cancel the print job. This functions accepts the job number.
     /// An exception will be thrown if access denied.
     /// </summary>
     /// <param name="printJobID">int: Job number to cancel printing for.</param>
     /// <returns>bool: true if cancel successfull, else false.</returns>
     public bool CancelPrintJob(int printJobID)
     {
          // Variable declarations.
          bool isActionPerformed = false;
          string searchQuery;
          String jobName;
          char[] splitArr;
          int prntJobID;
          ManagementObjectSearcher searchPrintJobs;
          ManagementObjectCollection prntJobCollection;
          try
          {
                // Query to get all the queued printer jobs.
               searchQuery = "SELECT * FROM Win32_PrintJob";
               // Create an object using the above query.
               searchPrintJobs = new ManagementObjectSearcher(searchQuery);
              // Fire the query to get the collection of the printer jobs.
               prntJobCollection = searchPrintJobs.Get();
               // Look for the job you want to delete/cancel.
               foreach (ManagementObject prntJob in prntJobCollection)
               {
                     jobName = prntJob.Properties["Name"].Value.ToString();
                     // Job name would be of the format [Printer name], [Job ID]
                     splitArr = new char[1];
                     splitArr[0] = Convert.ToChar(",");
                     // Get the job ID.
                     prntJobID = Convert.ToInt32(jobName.Split(splitArr)[1]);
                     // If the Job Id equals the input job Id, then cancel the job.
                     if (prntJobID == printJobID)
                     {
                           // Performs a action similar to the cancel
                           // operation of windows print console
                           prntJob.Delete();
                           isActionPerformed = true;
                           break;
                      }
               }
               return isActionPerformed;
          }
          catch (Exception sysException)
          {
               // Log the exception.
               return false;
           }
     }
