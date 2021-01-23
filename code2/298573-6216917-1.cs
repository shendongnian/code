&lt;database id="production">
  &lt;Engines.HistoryEngine.Storage>
    &lt;obj type="Sitecore.Data.$(database).$(database)HistoryStorage, Sitecore.Kernel">
      &lt;param connectionStringName="$(id)" />
      &lt;EntryLifeTime>30.00:00:00&lt;/EntryLifeTime>
    &lt;/obj>
  &lt;/Engines.HistoryEngine.Storage>
  &lt;Engines.HistoryEngine.SaveDotNetCallStack>false&lt;/Engines.HistoryEngine.SaveDotNetCallStack>
&lt;/database>
