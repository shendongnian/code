     foreach (var key in _dic.Keys.Where(key => _changedKeys.Contains(key))
     {
         foreach (var item in _dic[key].Where(item => _webSitePage.Session[key] != null))
         {
             item(_webSitePage.Session[key]);
         }
     }
