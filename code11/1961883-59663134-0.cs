        public ActionResult Test()
                {
                    var viewModel = new viewModel();
                    var startTime = DateTime.Now;
                    viewModel.Message = _importFactory.importScanSourceProductData(CurrentTenantId, "", null, CurrentUserId);
                    var endTime = DateTime.Now;
                    viewModel.EndTime =  endTime;
                    var elapsedTime = endTime - startTime;
                    viewModel.ElapsedTime =  elapsedTime;
                    return View(viewModel);
                }
