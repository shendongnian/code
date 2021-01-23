    var radioMetaKey=((IEnumerable<SepiaWEB.Models.Jobs.JobsMeta>)ViewData["JobMeta"])
        .Where(m=>m.vcr_JobMetaKey==JobsMeta.vcr_JobMetaKey);   
    
    var a= ViewData["JobMeta"]. as List<SepiaWEB.Models.Jobs.JobsMeta>;
    a.RemoveAll(x=> radioMetaKey.Contains(x));
