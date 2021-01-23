    Parallel.ForEach(Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories).AsParallel(), Item =>
            {
                if(!string.Equals(Path.GetExtension(Item), ".zip",StringComparison.OrdinalIgnoreCase))
                    File.Delete(Item);
            });
