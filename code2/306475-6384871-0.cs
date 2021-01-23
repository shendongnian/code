            if (ri != null)
            {
                var policyDocuments = ri.Controls.OfType<PolicyDocuments>().FirstOrDefault();
                if (policyDocuments == null)
                    return;
                if (policyDocuments.Visible)
                {
                    policyDocuments.Visible = false;
                }
                else
                {
                    policyDocuments.PolicyNumber = button.CommandArgument;
                    policyDocuments.Visible = true;
                }
            }
