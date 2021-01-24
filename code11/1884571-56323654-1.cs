    using (StreamReader reader = new StreamReader(HttpResponseStream))
    {
        //Response.Code = 1;
        string body = reader.ReadToEnd();
        consoleoutput("REST: result" + body);
        List<Entity> entities = JsonConvert.DeserializeObject<Entity>(body).ToList();
    }
