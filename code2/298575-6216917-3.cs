        <database id="production">
          <Engines.HistoryEngine.Storage>
            <obj type="Sitecore.Data.$(database).$(database)HistoryStorage, Sitecore.Kernel">
              <param connectionStringName="$(id)" />
              <EntryLifeTime>30.00:00:00</EntryLifeTime>
            </obj>
          </Engines.HistoryEngine.Storage>
          <Engines.HistoryEngine.SaveDotNetCallStack>false</Engines.HistoryEngine.SaveDotNetCallStack>
        </database>
