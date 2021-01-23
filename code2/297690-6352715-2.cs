    //
            public ActionResult Error(string errorCode)
            {
                var viewModel = new PageViewModel();
    
                int code = 0;
                int.TryParse(errorCode, out code);
                
                switch (code)
                {
                    case 403:
                        viewModel.HtmlTitleTag = GlobalFunctions.FormatTitleTag("403 Forbidden");
                        return View("403", viewModel);
                    case 404:
                        viewModel.HtmlTitleTag = GlobalFunctions.FormatTitleTag("404 Page Not Found");
                        return View("404", viewModel);
                    case 500:
                         viewModel.HtmlTitleTag = GlobalFunctions.FormatTitleTag("500 Internal Server Error");
                        return View("500", viewModel);
                    default:
                        viewModel.HtmlTitleTag = GlobalFunctions.FormatTitleTag("Embarrassing Error");
                        return View("GeneralError", viewModel);
                }
            }
