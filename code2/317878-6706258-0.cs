    /// <summary>
    /// Fonctions de gestion d'erreurs personnalisées.
    /// </summary>
    public class ErrorHandler
    {
        static string errLog = HttpContext.Current.Server.MapPath("~/Logs/errors.log");
        /// <summary>
        /// Affiche dans la page qu'une erreur s'est produite et l'indique dans un
        /// journal.
        /// Utiliser seulement si l'erreur est récupérable.
        /// </summary>
        /// <param name="strWhen">Complète la chaîne "Une erreur s'est produite ".
        /// Un "." sera ajouté après. Ex : "lors du chargement du calendrier"</param>
        /// <param name="strMessage">Le message d'erreur de l'exception. Sera encadré
        /// d'apostrophes.</param>
        static public void AddPageError(string strWhen, string strMessage)
        {
            string strPrefixe = "Une erreur s'est produite ";
            string strPage = HttpContext.Current.Request.Url.AbsolutePath;
            MasterPage mpMaster = ((Page)HttpContext.Current.Handler).Master;
            using (TextWriter errFile = new StreamWriter(errLog, true))
            {
                errFile.WriteLine(DateTime.Now.ToString() + " - (" + strPage + ") - " + strPrefixe + strWhen + " : '" + strMessage + "'");
            }
            Label lblAlert = (Label)((Page)HttpContext.Current.Handler).FindControl("lblAlert");
            // La boucle suivante sert à remonter les master page pour vérifier si un Label avec un id lblAlert existe.
            while (lblAlert == null)
            {
                if (mpMaster == null)
                    return;
                lblAlert = (Label)mpMaster.FindControl("lblAlert");
                mpMaster = mpMaster.Master;
            }
            // On ne veut pas continuer si le Label n'existe pas : Des erreurs se produiraient.
            if (lblAlert == null)
                return;
            if (lblAlert.Text == "")
            {
                lblAlert.Text = "<p><i>Cliquez pour faire disparaître.</i></p>";
            }
            lblAlert.Text += "<p>" + strPrefixe + strWhen + ".<br/>'" + strMessage + "'</p>";
            lblAlert.BorderWidth = Unit.Parse("0.3em");
            lblAlert.RenderControl(new HtmlTextWriter(HttpContext.Current.Response.Output));
        }
    }
