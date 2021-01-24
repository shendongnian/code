    [HttpPost]
        public async Task<JsonResult> SendBugReport(BugViewModel viewModel)
        {
            //Process Form
           
            string message;
            bool isError;
            
            //set data to message and isError
            return Json(new { message, isError });
           
        }
