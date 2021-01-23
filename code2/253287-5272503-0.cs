    <edmx:StorageModels>
    <Schema ...>
      ...
      <EntityType Name="CommissionPlanItems">
        <Key>
           <PropertyRef Name="CommissionPlanItemsId" />
           <PropertyRef Name="CommissionPlanId" /> <!-- This line added -->
        </Key>
      ...
      </Schema>
    </edmx:StorageModels>
    <edmx:ConceptualModels>
      <Schema ...>
          ...
         <EntityType Name="CommissionPlanItems">
            <Key>
              <PropertyRef Name="CommissionPlanItemsId" />
              <PropertyRef Name="CommissionPlanId" /> <!-- This line added -->
            </Key>
          ...
      </Schema>
    </edmx:ConceptualModels>
