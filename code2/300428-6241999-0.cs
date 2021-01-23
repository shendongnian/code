    <ItemGroup>
        <Compile Include="Model.Designer.cs">
            <AutoGen>True</AutoGen>
            <DesignTime>True</DesignTime>
            <DependentUpon>Model.edmx</DependentUpon>
        </Compile>
        <!-- other files included in the project -->
    </ItemGroup>
    <ItemGroup>
        <EntityDeploy Include="Model.edmx">
            <Generator>EntityModelCodeGenerator</Generator>
            <LastGenOutput>Model.Designer.cs</LastGenOutput>
        </EntityDeploy>
     </ItemGroup>
