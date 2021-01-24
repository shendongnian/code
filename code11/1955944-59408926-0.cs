    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Web;  
    using Quartz;  
    using Quartz.Impl;  
      
    namespace ScheduledTask.Models  
    {  
        public class JobScheduler  
        {  
            public static void Start()  
            {  
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();  
                scheduler.Start();  
      
                IJobDetail job = JobBuilder.Create<SendMailJob>().Build();  
      
                ITrigger trigger = TriggerBuilder.Create()  
                .WithIdentity("trigger1", "group1")  
                .StartNow()  
                .WithSimpleSchedule(x => x  
                .withIntervalInHours(24)  
                .RepeatForever())  
                .Build();  
      
                scheduler.ScheduleJob(job, trigger);  
            }  
        }  
    }  
2. Recreate your sending function to something like this
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using Quartz;  
using System.Net;  
using System.Net.Mail;  
  
namespace ScheduledTask.Models  
{  
    public class Jobclass:IJob  
    {       
        public void Execute(IJobExecutionContext context)  
        {  
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("mymail@mail.com", "Me");
                Msg.To.Add(new MailAddress("receivermail@mail.com", "ABC"));
 
                Msg.Subject = "Inviare Mail con C#";
                Msg.Body = "Mail Sended successfuly";
                Msg.IsBodyHtml = true;
                SmtpClient Smtp = new SmtpClient("smtp.live.com", 25);
                Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                Smtp.UseDefaultCredentials = false;
                NetworkCredential Credential = new
                NetworkCredential("mymail@mail.com", "password");
                Smtp.Credentials = Credential;
                Smtp.EnableSsl = true;
                Smtp.Send(Msg);
            }  
        }  
    }  
  
}  
In `global.asax.cs` in the application start event
    protected void Application_Start(Object sender, EventArgs e)
    {
        // keep whatever other code is there
        JobScheduler.Start();
    }
    
  [1]: https://www.c-sharpcorner.com/article/job-scheduling-in-Asp-Net-mvc-with-quartz-net/
