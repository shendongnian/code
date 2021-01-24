        [HttpGet]
        [Route("update")]
        public string GetUpdate(int progId, string version)
        {
            var update = db.Updates.FirstOrDefault(u => u.ProgramId == progId && u.Version == version);
            if (update != null)
            {
                return Convert.ToBase64String(update.Zip);
            }
            return "failed";
        }
