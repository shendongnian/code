    		<ContextMenu>
				<MenuItem Command="my:ImgTreeView.Folders" Header="Folders"
							  IsEnabled="{Binding Path=PlacementTarget.Tag.IsCheckFolder, RelativeSource={RelativeSource AncestorType=ContextMenu}}">
					<MenuItem.Icon>
							<Image Source="StarFolders.png" />
					</MenuItem.Icon>
				</MenuItem>
				<!-- ... -->
			</ContextMenu>
