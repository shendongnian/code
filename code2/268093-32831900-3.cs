        [HttpPost]
        [ValidateInput(false)]
        public FileResult Demo(CkEditorViewModel viewModel)
        {
            return File(WordHelper.HtmlToWord(viewModel.CkEditorContent),
              "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }
