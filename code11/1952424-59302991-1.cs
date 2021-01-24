    script.Compile();
    var stream = new MemoryStream();
    using (stream)
    {
      var emitResult = script.GetCompilation().Emit(stream);
      if (emitResult.Success)
        return Assembly.Load(stream.ToArray());
    }
