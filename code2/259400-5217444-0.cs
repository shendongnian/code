    <edmx:Edmx ...>
      <edmx:Runtime>
        <edmx:StorageModels> 
          <Schema ...>
            <EntityContainer Name="...">
              <EntitySet Name="Categories" EntityType="...Categories" store:Type="Tables" Schema="dbo" />
              ...
            </EntityContainer>
            <EntityType Name="Categories"/>
              ...
              <!-- Here you must add StoreGeneratedPattern -->
              <Property Name="CreationDate" Type="datetime" Nullable="false" StoreGeneratedPattern="Computed" /> 
            </EntityType>
          </Schema>
        </edmx:StorageModels>
        ...
      </edmx:Runtime>
    </edmx:Edmx>
