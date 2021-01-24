    <None Include="appsettings.json">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <CopyToPublishDirectory>Always</CopyToPublishDirectory>
      <ExcludeFromSingleFile>false</ExcludeFromSingleFile>
    </None>
    <None Include="appsettings.Development.json;appsettings.Production.json;">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <CopyToPublishDirectory>Always</CopyToPublishDirectory>
      <DependentUpon>appsettings.json</DependentUpon>
      <ExcludeFromSingleFile>false</ExcludeFromSingleFile>
    </None>
