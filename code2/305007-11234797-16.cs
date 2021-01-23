    <c:ModalContentPresenter IsModal="{Binding DialogIsVisible}">
        <TabControl Margin="5">
                <Button Margin="55"
                        Padding="10"
                        Command="{Binding ShowModalContentCommand}">
                    This is the primary Content
                </Button>
            </TabItem>
        </TabControl>
        <c:ModalContentPresenter.ModalContent>
            <Button Margin="75"
                    Padding="50"
                    Command="{Binding HideModalContentCommand}">
                This is the modal content
            </Button>
        </c:ModalContentPresenter.ModalContent>
    </c:ModalContentPresenter>
