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
