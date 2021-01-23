    FooBar
    |
     ---- FooBar.Common.Mvc
    |
     ---- FooBar.Common.DataAccess
    |
     ---- FooBar.Common.Linq
    |
     ---- FooBar.ProjectOne (ASP.NET MVC Web Application)
    |     |
    |      --- FooBar.ProjectOne.Repository (makes use of FooBar.Common.DataAccess)
    |     |
    |      --- FooBar.ProjectOne.WebMvc (makes use of FooBar.Common.Mvc)
    |
     ---- FooBar.ProjectTwo (WPF Application)
          |
           --- FooBar.ProjectTwo.Repository (makes use of FooBar.Common.DataAccess)
          |
           --- FooBar.ProjectTwo.BindingServices (makes use of FooBar.Common.Linq)
