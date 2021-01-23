    <Choose>
      <When Condition="'$(Platform)' == 'x64'">
        <ItemGroup>
          <Reference Include="System.Data.SQLite, Version=1.0.88.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139, processorArchitecture=AMD64">
            <SpecificVersion>False</SpecificVersion>
            <HintPath>System.Data.SQLite\x64\System.Data.SQLite.dll</HintPath>
          </Reference>
        </ItemGroup>
      </When>
      <When Condition="'$(Platform)' == 'x86'">
        <ItemGroup>
          <Reference Include="System.Data.SQLite, Version=1.0.88.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139, processorArchitecture=AMD64">
            <SpecificVersion>False</SpecificVersion>
            <HintPath>System.Data.SQLite\x86\System.Data.SQLite.dll</HintPath>
          </Reference>
        </ItemGroup>
      </When>
    </Choose>
    <ItemGroup>
      <Reference Include="Microsoft.CSharp" />
      <Reference Include="System" />
      <Reference Include="System.configuration" />
      <Reference Include="System.Core" />
      <Reference Include="System.Windows.Forms" />
      <Reference Include="System.Xml.Linq" />
      <Reference Include="System.Data.DataSetExtensions" />
      <Reference Include="System.Data" />
      <Reference Include="System.Xml" />
    </ItemGroup>
