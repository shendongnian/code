    <NonSerialized()> _
    Private m_ListChangedEvent As NotifyCollectionChangedEventHandler
    ''' <summary>
    ''' This event is raised whenever the list is changed and implements the IBindingList ListChanged event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Custom Event ListChanged As NotifyCollectionChangedEventHandler Implements INotifyCollectionChanged.CollectionChanged
        <MethodImpl(MethodImplOptions.Synchronized)> _
        AddHandler(ByVal value As NotifyCollectionChangedEventHandler)
            m_ListChangedEvent = DirectCast([Delegate].Combine(m_ListChangedEvent, value), NotifyCollectionChangedEventHandler)
        End AddHandler
        <MethodImpl(MethodImplOptions.Synchronized)> _
        RemoveHandler(ByVal value As NotifyCollectionChangedEventHandler)
            m_ListChangedEvent = DirectCast([Delegate].Remove(m_ListChangedEvent, value), NotifyCollectionChangedEventHandler)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If m_ListChangedEvent IsNot Nothing Then
                m_ListChangedEvent.Invoke(sender, e)
            End If
        End RaiseEvent
    End Event
