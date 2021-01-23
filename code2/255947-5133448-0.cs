    <Page DataContext="{Binding RelativeSource={RelativeSource Self}}">
        <TabControl>
            <TabItem>
               <BusyIndicator IsBusy="{Binding MyBooleanPropertyNameInCodeBehind}" /> 
            </TabItem>
        </TabControl>
    </Page>
