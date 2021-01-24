        List<Task<Uri>> tasks = new List<Task<Uri>>();
        foreach (Product product in products)
        {
            tasks.Add(Task.Run( async () =>  product.ImageUri = await _imageClient.GetImageUriAsync(product.GetImagePath()) ));
        }
        await Task.WhenAll(tasks);    
