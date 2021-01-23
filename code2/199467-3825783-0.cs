    <GridViewColumn Header="Validated">
      <GridViewColumn.CellTemplate>
        <DataTemplate>
            <Image Source="{Binding Path=Validated, Converter={StaticResource imageConverter}}" />
        </DataTemplate>
      </GridViewColumn.CellTemplate>
    </GridViewColumn>
