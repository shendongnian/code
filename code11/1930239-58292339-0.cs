    return Json(new
    {
        result = res,
        message = resp == null ? string.Empty : string.Join(";", 
            resp.Values.SelectMany(value => value
                .Where(validationResult => !string.IsNullOrEmpty(validationResult?.ErrorMessage))
                .Select(validationResult => validationResult.ErrorMessage)))
    }, JsonRequestBehavior.AllowGet);
