            cLogger oLogger = new cLogger();
            try
            {
                Object sLabel;
                sLabel = HttpContext.GetGlobalResourceObject("{filename}", sLabelID);
                if (sLabel.ToString() == "") //label was not found in selected lang
                {
                    //default to US language resource label
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    sLabel = HttpContext.GetGlobalResourceObject("{filename}", sLabelID);
                    //switch global lang back to selected
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(sLangCd);
                }
                return sLabel.ToString();
            }
            catch (Exception ex)
            {
                oLogger.LogWrite("cUtils.cs", "getLabelResource", ex.Message, false);
                return String.Empty;
            }
        }
