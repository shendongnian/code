    <TextBox Name="txtSearch" />
    <Image Name="ImageOne">
    	<Image.Style>
    		<Style TargetType="{x:Type Image}">
    			<Setter Property="Visibility" Value="Visible" />
    			<Style.Triggers>
    				<DataTrigger Binding="{Binding Text, ElementName=txtSearch}"
    							 Value="">
    					<Setter Property="Visibility" Value="Hidden" />
    				</DataTrigger>
    			</Style.Triggers>
    		</Style>
    	</Image.Style>
    </Image>
    <Image Name="ImageOne">
    	<Image.Style>
    		<Style TargetType="{x:Type Image}">
    			<Setter Property="Visibility" Value="Hidden" />
    			<Style.Triggers>
    				<DataTrigger Binding="{Binding Text, ElementName=txtSearch}"
    							 Value="">
    					<Setter Property="Visibility" Value="Visible" />
    				</DataTrigger>
    			</Style.Triggers>
    		</Style>
    	</Image.Style>
    </Image>
