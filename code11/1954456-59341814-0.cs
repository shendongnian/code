    public ActionResult DownloadPortfolio()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            User user = (User)Session["user"];
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "InvestorPortfolio.rpt"));
            rd.SetDatabaseLogon(DbKeyManager.DbUser, DbKeyManager.DbPass, DbKeyManager.DbSource, DbKeyManager.DbName);
            rd.SetParameterValue("@investorcode", user.InvestorCode);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", user.InvestorCode+"Portfolio-Statement.pdf");
        }
