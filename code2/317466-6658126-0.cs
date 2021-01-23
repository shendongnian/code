        public IEnumerable<TCProject> GetAllProjects()
        {
            var uri = _connection.CreateUri("/httpAuth/app/rest/projects");
            var request = _connection.Request(uri);
    
            var projects = JsonConvert.DeserializeObject<List<TCProject>>(request.Substring(11, request.Length - 1));
    
            return projects;
        }
