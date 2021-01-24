    var tasks = list.Select(async (index) => {
            var response = await client.GetAsync("posts/" + index);
            var contents = await response.Content.ReadAsStringAsync();
            listResults.Add(contents);
            Console.WriteLine(contents);
        });
    await Task.WhenAll(tasks);
