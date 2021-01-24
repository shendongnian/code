      <Target Name="ChangeAliasesOfStrongNameAssemblies" BeforeTargets="FindReferenceAssembliesForReferences;ResolveReferences">
        <ItemGroup>
          <ReferencePath Condition="'%(FileName)' == 'Microsoft.VisualStudio.Debugger.Interop'">
            <Aliases>signed</Aliases>
          </ReferencePath>
        </ItemGroup>
      </Target>
