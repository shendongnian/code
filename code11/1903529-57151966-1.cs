    [HttpPost]
        public ActionResult EditSafetyIncidentInLine([DataSourceRequest] DataSourceRequest request, SafetyIncidentViewModel sivm)
        {
            if (sivm != null && ModelState.IsValid)
            {
                SafetyIncident si = _safetyIncidentService.Find(sivm.Id);
                si.Description = sivm.Description;
                si.ProductionLineId = sivm.ProductionLineId;
                si.ProdLine = _productionLineService.Find(sivm.ProductionLineId);
                si.Type = sivm.Type;
                _safetyIncidentService.Update(si);
                sivm.Id = si.Id;
                sivm.CreatedAt = si.CreatedAt;
            }
            return this.Json(new[] { sivm }.ToDataSourceResult(request, ModelState));
        }
