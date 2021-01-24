c
public void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
        {
            // check if we already have an axis with that name and log and error if we do
            if (m_VirtualAxes.ContainsKey(axis.name))
            {
                //Debug.LogError("There is already a virtual axis named " + axis.name + " registered.");
                m_VirtualAxes.Remove(axis.name);
                m_VirtualAxes.Add(axis.name, axis);
                if (!axis.matchWithInputManager)
                {
                    m_AlwaysUseVirtual.Add(axis.name);
                }
            }
            else
            {
                // add any new axes
                m_VirtualAxes.Add(axis.name, axis);
                // if we dont want to match with the input manager setting then revert to always using virtual
                if (!axis.matchWithInputManager)
                {
                    m_AlwaysUseVirtual.Add(axis.name);
                }
            }
        }
