    public class GetModelErrors
    {
        //Usage return Json to View :
        //return Json(new { state = false, message = new GetModelErrors(ModelState).MessagesWithKeys() });
        public class KeyMessages
        {
            public string Key { get; set; }
            public string Message { get; set; }
        }
        private readonly ModelStateDictionary _entry;
        public GetModelErrors(ModelStateDictionary entry)
        {
            _entry = entry;
        }
        public int Count()
        {
            return _entry.ErrorCount;
        }
        public string Exceptions(string sp = "\n")
        {
            return string.Join(sp, _entry.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.Exception));
        }
        public string Messages(string sp = "\n")
        {
            string msg = string.Empty;
            foreach (var item in _entry)
            {
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    msg += string.Join(sp, string.Join(",", item.Value.Errors.Select(i => i.ErrorMessage)));
                }
            }
            return msg;
        }
        public List<KeyMessages> MessagesWithKeys(string sp = "<p> ● ")
        {
            List<KeyMessages> list = new List<KeyMessages>();
            foreach (var item in _entry)
            {
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    list.Add(new KeyMessages
                    {
                        Key = item.Key,
                        Message = string.Join(null, item.Value.Errors.Select(i => sp + i.ErrorMessage))
                    });
                }
            }
            return list;
        }
    }
