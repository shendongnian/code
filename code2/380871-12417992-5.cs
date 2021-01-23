    <myClass xmlns="clr-namespace:test;assembly=ConsoleApplication2"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <myClass.Countries>
            <Country x:Name="UK">
                <Country.Languages>
                    <x:Array Type="Language">
                        <x:Reference Name="English" />
                    </x:Array>
                </Country.Languages>
            </Country>
            <Country x:Name="France">
                <Country.Languages>
                    <x:Array Type="Language">
                        <x:Reference Name="French" />
                    </x:Array>
                </Country.Languages>
            </Country>
            <Country x:Name="Italy">
                <Country.Languages>
                    <x:Array Type="Language">
                        <x:Reference Name="Italian" />
                    </x:Array>
                </Country.Languages>
            </Country>
            <Country x:Name="Switzerland">
                <Country.Languages>
                    <x:Array Type="Language">
                        <x:Reference Name="English" />
                        <x:Reference Name="French" />
                        <x:Reference Name="Italian" />
                    </x:Array>
                </Country.Languages>
            </Country>
        </myClass.Countries>
        <myClass.Languages>
            <Language x:Name="English" />
            <Language x:Name="French" />
            <Language x:Name="Italian" />
        </myClass.Languages>
    </myClass>
