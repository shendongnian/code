    catch (WebException ex)
    {
        using (var stream = ex.Response.GetResponseStream())
        using (var reader = new StreamReader(stream))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
    catch (Exception ex)
    {
        // Something more serious happened
    }
