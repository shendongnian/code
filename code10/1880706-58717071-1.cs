    <Project>
      ...
      <Choose>
        <When Condition="$(MSBuildProjectName)!='Analyzer' AND ...">
          <ItemGroup>
            <ProjectReference Include="..\Analyzer\Analyzer.csproj">
              <ReferenceOutputAssembly>false</ReferenceOutputAssembly>
              <OutputItemType>Analyzer</OutputItemType>
            </ProjectReference>
          </ItemGroup>
        </When>
        <Otherwise>
           ...
        </Otherwise>
      </Choose>
      
      ...
    </Project>
