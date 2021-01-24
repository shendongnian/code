<ItemGroup>
    <None Include="appsettings.json">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <CopyToPublishDirectory>Always</CopyToPublishDirectory>
      <ExcludeFromSingleFile>true</ExcludeFromSingleFile>
    </None>
    <None Include="appsettings.Development.json;appsettings.QA.json;appsettings.Production.json;">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <CopyToPublishDirectory>Always</CopyToPublishDirectory>
      <DependentUpon>appsettings.json</DependentUpon>
      <ExcludeFromSingleFile>true</ExcludeFromSingleFile>
    </None>
  </ItemGroup>
  <ItemGroup>
    <None Include="Views\Test.cshtml">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <ExcludeFromSingleFile>true</ExcludeFromSingleFile>
    </None>
  </ItemGroup>
If this is not acceptable, and must have ONLY a single file, I pass the single-file-extracted path as the root path in my host setup. This allows configuration, and razor (which I add after), to find its files as normal.
// when using single file exe, the hosts config loader defaults to GetCurrentDirectory
            // which is where the exe is, not where the bundle (with appsettings) has been extracted.
            // when running in debug (from output folder) there is effectively no difference
            var realPath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            var host = Host.CreateDefaultBuilder(args).UseContentRoot(realPath);
