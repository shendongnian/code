       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Web;
       using System.Web.Http;
       using System.Web.Mvc;
       using System.Web.Optimization;
       using System.Web.Routing;
       using System.Reflection;
       using System.Web.Configuration;
       using System.Text.RegularExpressions;
    
       namespace mvcapp
       {
         // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
         // visit http://go.microsoft.com/?LinkId=9394801
    
         public class MvcApplication : System.Web.HttpApplication
         {
           protected void Application_Start()
           {
             var domain = AppDomain.CurrentDomain;
       
             domain.Load("MessagingModule, Version=1.0.0.0, Culture=neutral,   PublicKeyToken=null");
