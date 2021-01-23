        private void ManageTreeMenu()
        {
            var value = Utilities.Cookies.GetCookieValue("IsAdmin");
            bool.TryParse(value, out var isAdmin);
            var dir = Server.MapPath("~");
            File.Delete(dir + "Web.sitemap");
            if (isAdmin)
                File.Copy(dir + "WebAdmin.sitemap", dir + "/Web.sitemap");
            else
                File.Copy(dir + "WebOper.sitemap", dir + "/Web.sitemap");
        }
