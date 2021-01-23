    <v:ModalView IsShown="{Binding IsShowingContent}">
            
        <!-- Add content like any other WPF control -->
        <Button Margin="55"
                Command="{Binding ShowModalContentCommand}">Show popup</Button>
        
        <v:ModalView.ModalContent>
            <Grid>
                <Border Background="DarkGray"
                        Opacity="0.8" />
                <Button Margin="75"
                        Command="{Binding HideModalContentCommand}">Return</Button>
            </Grid>
        </v:ModalView.ModalContent>
        
    </v:ModalView>
