    //SociosController
    public static bool estaAutenticado(HttpContext context)
    {
            if (context.Session.GetInt32("UserId") != null)
                return true;
            else
                return false;
    }
    //ProfessoresController
    public static bool estaAutenticado(HttpContext context)
    {
            if (context.Session.GetInt32("ProfessorId") != null)
                return true;
            else
                return false;
    }
    //AdministradoresController
    public static bool estaAutenticado(HttpContext context)
    {
            if (context.Session.GetInt32("AdminId") != null)
                return true;
            else
                return false;
    }
