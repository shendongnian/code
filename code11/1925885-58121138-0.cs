    [ActionName("proj")]
        [HttpPost]
        public IActionResult Projects(ReleaseViewModel model)
        {
            UpdateProjectList(model.Paths);
            StatusMessage = "Successfully updated the project list";
            return RedirectToAction(nameof(Projects));
        }
